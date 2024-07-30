export const sortRemindersByDate = (reminders) => {
    return reminders.sort((a, b) => new Date(a.data) - new Date(b.data));
};

export const groupRemindersByDate = (reminders) => {
    const groupedReminders = {};
    reminders.forEach(reminder => {
        const data = new Date(reminder.data).toLocaleDateString();
        if (!groupedReminders[data]) {
            groupedReminders[data] = [];
        }
        groupedReminders[data].push(reminder);
    });
    return groupedReminders;
};

