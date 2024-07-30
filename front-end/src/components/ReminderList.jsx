import { TrashIcon } from "lucide-react";
import PropTypes from 'prop-types';
import { useReminder } from '../hooks/useReminder';
import { groupRemindersByDate, sortRemindersByDate } from '../utils/DataUtils';
import '../styles/lista-de-lembrete.scss';


const ReminderList = () => {
    const { reminders, deleteReminderById } = useReminder();

    const renderReminders = () => {

        const orderedReminders = sortRemindersByDate(reminders);

        const groupedReminders = groupRemindersByDate(orderedReminders);

        return Object.entries(groupedReminders).map(([data, reminders]) => (
            <div key={data} className="lembrete-list">
                <h2>{data}</h2>
                <ul>
                    {reminders.map(reminder => ( 
                        <li key={reminder.id} className="lembrete-info">
                            {reminder.nome}
                            <span onClick={() => deleteReminderById(reminder.id)} className="delete-icon">
                                <TrashIcon />
                            </span>
                        </li>
                    ))}
                </ul>
            </div>
        ));
    };

    return (
        <div>
            {renderReminders()}
        </div>
    );
};

ReminderList.propTypes = {
    reminders: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.number.isRequired,
            nome: PropTypes.string.isRequired,
            data: PropTypes.string.isRequired
        })
    ).isRequired
};

export default ReminderList;
