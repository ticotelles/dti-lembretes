import ReminderForm from './components/ReminderForm'
import ReminderList from './components/ReminderList'
import { useState } from 'react';
import './App.scss'

function App() {

  const [reminders, setReminders] = useState([]);

  const addReminderList = (newReminder) => {
    setReminders([...reminders, newReminder]);
  };

  return (
    <>
      <ReminderForm addReminder={addReminderList} />
      <ReminderList reminders={reminders} />
    </>
  )
}

export default App
