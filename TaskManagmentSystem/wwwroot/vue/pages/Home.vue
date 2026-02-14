<script setup>
import { ref } from 'vue'
import GreetingHomeScreen from '../components/greetingHomeScreen.vue'
import TotalsHomeScreen from '../components/totalsHomeScreen.vue'
import StreakHomeScreen from '../components/streakHomeScreen.vue'
import LeaderBoardHomeScreen from '../components/leaderBoardHomeScreen.vue'
import { useHome } from '../utils/homeUtils.js'

const user = ref({
  name: 'Bdiwy',
})

const prop = defineProps({
  AnalysisData: {
    type: Object,
    required: false,
    default: () => ({
      TotalTasks: 0,
      TotalTimeLoggedInHours: 0,
      TotalWorkSpaces: 0,
      UserCurrentStreak: 0,
      UserLongestStreak: 0
    })
  }
})

// Ensure we always have a valid object
const analysisData = prop.AnalysisData || {
  TotalTasks: 0,
  TotalTimeLoggedInHours: 0,
  TotalWorkSpaces: 0,
  UserCurrentStreak: 0,
  UserLongestStreak: 0
}

const stats = ref({
  tasks: analysisData.TotalTasks ?? 0,
  timeLogged: `${analysisData.TotalTimeLoggedInHours || 0}h`,
  progress: 78,
  workspaces: analysisData.TotalWorkSpaces ?? 0,
  userStreak: analysisData.UserCurrentStreak ?? 0
})

const isLoading = ref(false)


const { refreshData, greeting, streakInfo } = window.useHome(stats, isLoading)

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


</script>

<template>
  <div class="analytics-container">
    <header class="welcome-header">
      <greeting-home-screen
        :user_name="user.name"
        :greeting="greeting"
        :todayDate="todayDate"
        :isLoading="isLoading"
        :refreshData="refreshData"
      />
    </header>

    <totals-home-screen
      :stats="stats"
      :isLoading="isLoading"
    />

    <streak-home-screen
      :stats="stats"
      :isLoading="isLoading"
      :streakInfo="streakInfo" 
    />

    <leader-board-home-screen
      :topUsers="topUsers"
    />
  </div>
</template>

<style src="../css/home.css" ></style>