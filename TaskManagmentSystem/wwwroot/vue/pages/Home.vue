<script setup>
import { ref } from 'vue'

const props = defineProps({
  userName: String,
  userRole: String
})

const welcomeMessage = ref('أهلاً بك في مديول الصفحة الرئيسية')
</script>

<template>
  <div class="page-container">
    <div class="welcome-card">
      <h1>{{ welcomeMessage }}</h1>
      
      <div class="user-info">
        <p>مرحباً يا: <strong>{{ userName }}</strong></p>
        <span class="badge">{{ userRole }}</span>
      </div>
    </div>
  </div>
</template>

<style scoped>
  .page-container {
    padding: 20px;
    display: flex;
    justify-content: center;
  }
  .welcome-card {
    background: #1e293b;
    color: white;
    padding: 2rem;
    border-radius: 16px;
    text-align: center;
    box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1);
  }
  .user-info {
    margin-top: 20px;
    padding-top: 15px;
    border-top: 1px solid #334155;
  }
  .badge {
    background: #8b5cf6;
    padding: 4px 12px;
    border-radius: 20px;
    font-size: 0.8rem;
  }
</style>