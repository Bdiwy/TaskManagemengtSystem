<script setup>
defineProps({
    topUsers: {
        type: Array,
        required: true
    }
})
</script>

<template>
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
                <tr v-for="(user, index) in topUsers" :key="user.id"
                    :class="['rank-row', { 'rank-gold': index === 0, 'rank-silver': index === 1, 'rank-bronze': index === 2 }]">
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
</template>