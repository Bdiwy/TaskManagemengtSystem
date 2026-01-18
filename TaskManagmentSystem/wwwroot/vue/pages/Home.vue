<script setup>
import { ref, computed } from 'vue'

// داتا المستخدم
const user = ref({
  name: 'Bdiwy',
  avatar: '👤'
})

const stats = ref({
  tasks: 124,
  timeLogged: '145h 30m',
  progress: 78,
  workspaces: 12,
  userStreak: 9120
})

const isLoading = ref(false)

const refreshData = async () => {
  isLoading.value = true
  
  await new Promise(resolve => setTimeout(resolve, 1500))
  
  stats.value.tasks += Math.floor(Math.random() * 3)
  stats.value.progress = Math.min(100, stats.value.progress + 2)
  
  isLoading.value = false
}

const greeting = computed(() => {
  const hour = new Date().getHours()
  if (hour < 12) return 'Good Morning'
  if (hour < 18) return 'Good Afternoon'
  return 'Good Evening'
})

const todayDate = new Date().toLocaleDateString('en-US', { 
  weekday: 'long', 
  year: 'numeric', 
  month: 'long', 
  day: 'numeric' 
})

const topUsers = ref([
  { id: 1, name: 'Ahmed', streak: 95 },
  { id: 2, name: 'Sara', streak: 50 },
  { id: 3, name: 'Bdiwy', streak: 48 },
  { id: 4, name: 'Hassan', streak: 35 },
  { id: 5, name: 'Mona', streak: 25 },
  { id: 6, name: 'Omar', streak: 15 },
  { id: 7, name: 'Ali', streak: 10 },
  { id: 8, name: 'Nour', streak: 5 },
  { id: 9, name: 'Zain', streak: 3 },
  { id: 10, name: 'Laila', streak: 1 }
])

const streakInfo = computed(() => {
  const s = stats.value.userStreak
  if (s >= 90) return { class: 'insane-skull', label: 'INSANE', icon: '💀' }
  if (s >= 45) return { class: 'gold-premium', label: 'PREMIUM', icon: '👑🔥' }
  if (s >= 30) return { class: 'gold', label: 'GOLD', icon: '👑' }
  if (s >= 21) return { class: 'gray', label: 'PRO', icon: '⚡' }
  if (s >= 7) return { class: 'silver', label: 'ROOKIE', icon: '🥈' }
  
  return { class: 'normal', label: 'BEGINNER', icon: '🌱' }
})
</script>

<template>
  <div class="analytics-container">
    
    <header class="welcome-header">
      <div class="user-info">
        <span class="user-avatar">{{ user.avatar }}</span>
        <div class="welcome-text">
          <h1>{{ greeting }}, {{ user.name }}!</h1>
          <p>{{ todayDate }}</p>
        </div>
      </div>
      <div class="header-action">
        <button class="btn-refresh" @click="refreshData" :disabled="isLoading">
          <span v-if="!isLoading">🔄 Refresh Data</span>
          <div v-else class="loader-content">
            <div class="spinner"></div>
            <span>Updating...</span>
          </div>
        </button>
      </div>
    </header>

    <div class="stats-grid" :class="{ 'is-refreshing': isLoading }">
      <div v-for="(val, key) in { Tasks: stats.tasks, 'Time Logged': stats.timeLogged, Progress: stats.progress + '%', Workspaces: stats.workspaces }" 
           :key="key" class="stat-card">
        <h3>{{ key }}</h3>
        <p class="value">{{ val }}</p>
      </div>
    </div>

    <div class="streak-section" :class="{ 'is-refreshing': isLoading }">
      <div :class="['streak-main-card', streakInfo.class]">
        <div class="streak-icon">{{ streakInfo.icon }}</div>
        <div class="streak-details">
          <span class="badge">LEVEL: {{ streakInfo.label }}</span>
          <h4>{{ stats.userStreak }} DAY STREAK</h4>
          <p v-if="stats.userStreak < 7" class="promo-text">Only {{ 7 - stats.userStreak }} days to Silver!</p>
          <p v-else class="promo-text">Keep the flame alive!</p>
        </div>
      </div>
    </div>

    <div class="leaderboard">
      <h3>🏆 Global Leaderboard</h3>
      <table>
        <thead>
          <tr>
            <th>Rank</th>
            <th>User</th>
            <th>Streak</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(user, index) in topUsers" 
              :key="user.id" 
              :class="['rank-row', {'rank-gold': index === 0, 'rank-silver': index === 1, 'rank-bronze': index === 2}]">
            <td class="rank-col">
              <span class="rank-badge">
                {{ index === 0 ? '🥇' : index === 1 ? '🥈' : index === 2 ? '🥉' : '#' + (index + 1) }}
              </span>
            </td>
            <td class="user-name">{{ user.name }}</td>
            <td class="streak-col">
              <span class="streak-tag">{{ user.streak }} Days</span>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<style scoped>
.analytics-container { padding: 2rem; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background: #f4f7f6; min-height: 100vh; }

/* Welcome Header */
.welcome-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 2rem; padding: 1rem 0; }
.user-info { display: flex; align-items: center; gap: 1rem; }
.user-avatar { font-size: 2.5rem; background: #fff; padding: 10px; border-radius: 50%; box-shadow: 0 4px 10px rgba(0,0,0,0.05); }
.welcome-text h1 { font-size: 1.8rem; margin: 0; color: #2c3e50; font-weight: 800; }
.welcome-text p { margin: 0; color: #7f8c8d; font-size: 0.95rem; }

/* Refresh Button & Loader */
.btn-refresh {
  background: white; border: 1px solid #e0e0e0; padding: 10px 22px; border-radius: 14px;
  font-weight: 600; cursor: pointer; transition: all 0.3s; min-width: 150px;
}
.btn-refresh:hover:not(:disabled) { background: #f8f9fa; transform: translateY(-2px); box-shadow: 0 4px 12px rgba(0,0,0,0.05); }
.btn-refresh:disabled { opacity: 0.7; cursor: not-allowed; background: #fafafa; }

.loader-content { display: flex; align-items: center; justify-content: center; gap: 10px; color: #42b883; }

.spinner {
  width: 18px; height: 18px; border: 2.5px solid #e0e0e0; border-top: 2.5px solid #42b883;
  border-radius: 50%; animation: spin 0.8s linear infinite;
}

@keyframes spin { 0% { transform: rotate(0deg); } 100% { transform: rotate(360deg); } }

/* Refreshing State Effect */
.is-refreshing { filter: blur(2px); opacity: 0.7; pointer-events: none; transition: all 0.4s ease; }

/* Stats Grid */
.stats-grid { display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 1.5rem; margin-bottom: 2.5rem; }
.stat-card { 
  background: white; padding: 1.5rem; border-radius: 16px; border: 1px solid #e0e0e0; 
  text-align: center; transition: all 0.4s cubic-bezier(0.175, 0.885, 0.32, 1.275); cursor: pointer;
}
.stat-card:hover { transform: translateY(-12px); box-shadow: 0 20px 40px rgba(0,0,0,0.08); border-color: #42b883; }
.stat-card h3 { font-size: 0.9rem; color: #7f8c8d; text-transform: uppercase; margin-bottom: 0.5rem; }
.stat-card .value { font-size: 2rem; font-weight: 800; color: #2c3e50; }

/* Streak Cards Tiers */
.streak-main-card { display: flex; align-items: center; padding: 2.5rem; border-radius: 24px; color: white; margin-bottom: 2.5rem; position: relative; overflow: hidden; }
.streak-icon { font-size: 4.5rem; margin-right: 2rem; filter: drop-shadow(0 5px 15px rgba(0,0,0,0.2)); }
.streak-details h4 { font-size: 2.2rem; margin: 0.5rem 0; font-weight: 900; }
.streak-details .badge { background: rgba(255,255,255,0.2); padding: 4px 12px; border-radius: 50px; font-size: 0.75rem; font-weight: bold; }

.normal { background: linear-gradient(135deg, #42b883, #34495e); }
.silver { background: linear-gradient(135deg, #bdc3c7, #2c3e50); }
.gray { background: linear-gradient(135deg, #3f4c6b, #606c88); }
.gold { background: linear-gradient(135deg, #f1c40f, #f39c12); }
.gold-premium { background: radial-gradient(circle, #f39c12, #d35400); animation: glow 2s infinite; }
.insane-skull { background: #000; border: 3px solid #ff0000; box-shadow: 0 0 40px rgba(255,0,0,0.4); }

@keyframes glow { 0%, 100% { box-shadow: 0 0 10px #f39c12; } 50% { box-shadow: 0 0 30px #f39c12; } }

/* Leaderboard Styling */
.leaderboard { background: white; border-radius: 24px; padding: 2rem; box-shadow: 0 10px 30px rgba(0,0,0,0.03); }
table { width: 100%; border-spacing: 0 10px; border-collapse: separate; }
th { text-align: left; padding: 0 1.2rem 1rem; color: #95a5a6; font-size: 0.85rem; text-transform: uppercase; }
.rank-row td { padding: 1.2rem; background: #fbfcfc; transition: all 0.2s ease; }
.rank-row td:first-child { border-radius: 16px 0 0 16px; }
.rank-row td:last-child { border-radius: 0 16px 16px 0; }

.rank-gold td { background: #fffdf2 !important; border-top: 1px solid #f1c40f; border-bottom: 1px solid #f1c40f; }
.rank-silver td { background: #f8f9fa !important; border-top: 1px solid #bdc3c7; border-bottom: 1px solid #bdc3c7; }
.rank-bronze td { background: #fff8f4 !important; border-top: 1px solid #cd7f32; border-bottom: 1px solid #cd7f32; }

.streak-tag { padding: 6px 16px; border-radius: 50px; font-weight: bold; background: #e8f5e9; color: #2e7d32; }
</style>