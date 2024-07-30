export const validateField = (nome, data) => {
    if (!nome.trim() || !data.trim()) {
        return 'Por favor, preencha todos os campos obrigatórios.';
    }

    const today = new Date();
    const selectedDate = new Date(data);

    if (selectedDate < today) {
        return 'A data deve ser maior ou igual à data atual.';
    }

    return '';
};