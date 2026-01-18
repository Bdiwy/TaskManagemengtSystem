<script setup>
    defineProps({
    stats: {
        type: Object,
        required: true
    },
    isLoading: {
        type: Boolean,
        required: true
    }
    })
</script>


<template>
<div class="stats-grid" :class="{ 'is-refreshing': isLoading }">
        <div v-for="(val, key) in { Tasks: stats.tasks, 'Time Logged': stats.timeLogged, Progress: stats.progress + '%', Workspaces: stats.workspaces }" 
            :key="key" class="stat-card">
        <h3>{{ key }}</h3>
        <p class="value">{{ val }}</p>
    </div>
    </div>

</template>