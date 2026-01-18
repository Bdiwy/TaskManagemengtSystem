<script setup>
    defineProps({
    user_name: {
        type: String,
        required: true
    },
    greeting: {
        type: String,
        required: true
    },
    todayDate: {
        type: String,
        required: true
    },
    isLoading: {
        type: Boolean,
        required: true
    },
    refreshData: {
        type: Function,
        required: true
    }
    })
</script>

<template>
        <div class="user-info">
            <div class="welcome-text">
                <h1>{{ greeting }}, {{ user_name }}!</h1>
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
</template>