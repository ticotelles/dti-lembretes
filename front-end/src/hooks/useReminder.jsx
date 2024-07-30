import { useEffect, useState } from 'react';
import { getReminder, deleteReminder, addReminder } from '../services/ReminderService';

export const useReminder = () => {
    const [reminders, setReminders] = useState([]);

    useEffect(() => {
        getReminder()
            .then(data => {
                setReminders(data);
            })
            .catch(error => console.error('Error fetching lembretes:', error));
    }, []);

    const deleteReminderById = async (id) => {
        try {
            await deleteReminder(id);
            setReminders(reminders.filter(reminder => reminder.id !== id));
            console.log('Lembrete deleted successfully');
        } catch (error) {
            console.error('Error deleting lembrete:', error);
        }
    };

    const addNewReminder = async (newReminder) => {
        try {
            const reminderAdded = await addReminder(newReminder);
            setReminders([...reminders, reminderAdded]);
            console.log('Lembrete adicionado com sucesso');
        } catch (error) {
            console.error('Erro ao adicionar lembrete:', error);
        }
    };

    return { reminders, deleteReminderById, addNewReminder };
};
