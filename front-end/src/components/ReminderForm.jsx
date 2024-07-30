import { useState } from 'react';
import { useReminder } from '../hooks/useReminder';
import { useForm } from '../hooks/useForm';
import { validateField } from '../utils/Validation';
import '../styles/form.scss';

const ReminderForm = () => {
    const { addNewReminder } = useReminder();
    const { values, handleChange, resetForm } = useForm({ nome: '', data: '' });
    const [erro, setErro] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const msgErro = validateField(values.nome, values.data);
        if (msgErro) {
            setErro(msgErro);
            return;
        }

        try {
            await addNewReminder(values);
            resetForm();
            setErro('');
        } catch (error) {
            setErro('Erro ao adicionar lembrete.');
        }
    };

    return (
        <form className="lembrete-form" onSubmit={handleSubmit}>
            <h1>Todo List</h1>
            {erro && <p className="erro">{erro}</p>}
            <input type="text" placeholder="Adiciona aqui um Lembrete..." name="nome" value={values.nome} onChange={handleChange} />
            <input type="date" placeholder="Data" name="data" value={values.data} onChange={handleChange} />
            <button type="submit">Salvar</button>
        </form>
    );
};

export default ReminderForm;
