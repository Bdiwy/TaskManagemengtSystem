// لا تستخدم import هنا
const { computed } = Vue; 

// بدلاً من export function استخدم الطريقة التي يفهمها الـ loader
// أو عرفها كدالة عادية وسنقوم باستدعائها
window.useHome = function(stats, isLoading) {
  const streakInfo = computed(() => {
    const s = stats.value.userStreak;
    if (s >= 90) return { class: 'insane-skull', label: 'INSANE', icon: '💀' };
    if (s >= 45) return { class: 'gold-premium', label: 'PREMIUM', icon: '👑🔥' };
    if (s >= 30) return { class: 'gold', label: 'GOLD', icon: '👑' };
    if (s >= 21) return { class: 'gray', label: 'PRO', icon: '⚡' };
    if (s >= 7) return { class: 'silver', label: 'ROOKIE', icon: '🥈' };
    return { class: 'normal', label: 'BEGINNER', icon: '🌱' };
  });

  const refreshData = async () => {
    isLoading.value = true;
    await new Promise(resolve => setTimeout(resolve, 1500));
    stats.value.tasks += Math.floor(Math.random() * 3);
    stats.value.progress = Math.min(100, stats.value.progress + 2);
    isLoading.value = false;
  };

  const greeting = computed(() => {
    const hour = new Date().getHours();
    if (hour < 12) return 'Good Morning';
    if (hour < 18) return 'Good Afternoon';
    return 'Good Evening';
  });

  return { streakInfo, refreshData, greeting };
}