using Microsoft.EntityFrameworkCore;
using TaskManagmentSystem.Helpers;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
using TaskManagmentSystem.Srvices.Interfaces;

namespace TaskManagmentSystem.Repositories
{
    public class WorkSpaceRepository : IWorkSpaceRepository
    {
        private readonly AppDbContext _context;
        private readonly ITeamService _teamService;
        private readonly ILogger<WorkSpaceRepository> _logger;

        public WorkSpaceRepository(AppDbContext context, ITeamService teamService, ILogger<WorkSpaceRepository> logger)
        {
            _context = context;
            _teamService = teamService;
            _logger = logger;
        }

        public async Task<OperationResult<TimeLog>> GetByIdAsync(int id)
        {
            var workSpace = await _context.WorkSpaces.FindAsync(id);
            if (workSpace == null)
                return OperationResult<TimeLog>.Failure("WorkSpace not found");
            return OperationResult<TimeLog>.Success(workSpace);
        }
        public async Task<OperationResult> CreateAsync(TimeLog workSpace)
        {
            _context.WorkSpaces.Add(workSpace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating WorkSpace with Title: {Title}", workSpace.Title);
                return OperationResult.Failure("An error occurred while creating the WorkSpace: " + ex.Message);
            }
            
            return OperationResult.Success();
        }
        public async Task<OperationResult> UpdateAsync(TimeLog workSpace)
        {
            _context.WorkSpaces.Update(workSpace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating WorkSpace with Title: {Title}", workSpace.Title);
                return OperationResult.Failure("An error occurred while updating the WorkSpace: " + ex.Message);
            }
            return OperationResult.Success();
        }
        public async Task<OperationResult> DeleteAsync(int id)
        {
            var workSpace = await _context.WorkSpaces.FindAsync(id);
            if (workSpace == null)
                return OperationResult.Failure("WorkSpace not found");
            _context.WorkSpaces.Remove(workSpace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while Deleting WorkSpace with Title: {Title}", workSpace.Title);
                return OperationResult.Failure("An error occurred while Deleting the WorkSpace: " + ex.Message);
            }
            return OperationResult.Success();
        }
        public async Task<OperationResult<List<TimeLog>>> GetForUserAsync(string userId)
        {
            var workSpaces = await _context.WorkSpaces
                .Where(ws => ws.AppUserId == userId)
                .ToListAsync();
            return OperationResult<List<TimeLog>>.Success(workSpaces);
        }

        public async Task<OperationResult<List<TimeLog>>> GetForTeamAsync(int teamId)
        {
            var teamResult = await _teamService.GetByIdAsync(teamId);
            if(!teamResult.Succeeded)
                return OperationResult<List<TimeLog>>.Failure("Team not found");

            var workSpaces = await _context.WorkSpaces
                .Where(ws => ws.TeamId == teamId)
                .ToListAsync();
            return OperationResult<List<TimeLog>>.Success(workSpaces);
        }
    }
}
