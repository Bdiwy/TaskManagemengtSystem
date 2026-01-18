<script setup>
import { ref, computed } from 'vue'

const user = ref({
  name: 'Bdiwy',
})

const stats = ref({
  tasks: 124,
  timeLogged: '145h 30m',
  progress: 78,
  workspaces: 12,
  userStreak: 88
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

<style src="../css/home.css" scoped></style>