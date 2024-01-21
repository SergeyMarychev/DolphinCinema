const updateDates = () => {
    const dates = document.querySelectorAll('.timeBtn');

    const currentDate = new Date();

    for (let i = 0; i < dates.length; i++) {
        const dateElement = dates[i].querySelector('span');
        const options = { weekday: 'long', month: 'long', day: 'numeric' }; // убрали 'year'
        const formattedDate = currentDate.toLocaleDateString('ru-RU', options);

        if (i >= 2) {
            dateElement.textContent = formattedDate;
        }

        dateElement.parentElement.dataset.date = currentDate;
        currentDate.setDate(currentDate.getDate() + 1); // увеличиваем текущую дату на 1 день
    }
}

// Первоначальное обновление дат при загрузке страницы
updateDates();