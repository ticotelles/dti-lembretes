export const getReminder = async () => {
    return fetch("http://localhost:5103/api/Nota", {
      method: 'GET',
      headers: { 'Content-Type': 'application/json' }
    }).then(response => response.json());
  }
  
  export const deleteReminder = async (id) => {
    return fetch(`http://localhost:5103/api/Nota/${id}`, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json' }
    }).then(response => {
      if (!response.ok) throw new Error('Falha ao deletar lembrete');
      return;
    });
  }

  export const addReminder = async (newRimender) => {
    return fetch("http://localhost:5103/api/Nota", {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(newRimender)
    }).then(response => {
      if (!response.ok) throw new Error('Erro ao criar novo lembrete');
      else window.location.reload()
      return response.json();
    });
  };
    