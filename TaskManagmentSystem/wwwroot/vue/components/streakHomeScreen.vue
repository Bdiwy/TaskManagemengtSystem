<script setup>
    defineProps({
    stats: {
        type: Object,
        required: true
    },
    isLoading: {
        type: Boolean,
        required: true
    },
    streakInfo: {
        type: Object,
        required: true
    }
})
</script>

<template>
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
</template>