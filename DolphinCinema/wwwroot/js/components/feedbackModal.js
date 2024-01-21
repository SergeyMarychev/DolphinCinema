document.addEventListener('DOMContentLoaded', function () {
    const feedbackBtn = document.querySelector('.feedback__btn');
    const popupContainer = document.querySelector('.popup');

    feedbackBtn.addEventListener('click', function () {
        popupContainer.removeAttribute('hidden');
        resetForm();
    });

    const popupExit = document.querySelector('.popup__exit');
    const btnCancel = document.querySelector('.btn__cancel');
    const btnSend = document.querySelector('.btn__send');

    const closePopup = () => {
        popupContainer.setAttribute('hidden', '');
        resetForm();
    }

    popupExit.addEventListener('click', closePopup);
    btnCancel.addEventListener('click', closePopup);

    btnSend.addEventListener('click', function () {
        const nameInput = document.querySelector('.input[name="name"]');
        const contactInput = document.querySelector('.input[name="contact"]');
        const messageTextarea = document.querySelector('.textarea[name="message"]');

        if (nameInput.value.trim() === '') {
            nameInput.style.borderColor = 'red';
        } else {
            nameInput.style.borderColor = '#c9c9c9';
        }

        if (contactInput.value.trim() === '') {
            contactInput.style.borderColor = 'red';
        } else {
            contactInput.style.borderColor = '#c9c9c9';
        }

        if (messageTextarea.value.trim() === '') {
            messageTextarea.style.borderColor = 'red';
        } else {
            messageTextarea.style.borderColor = '#c9c9c9';
            sendFeedback();
        }
    });

    const sendFeedback = () => {
        const nameInput = document.querySelector('.input[name="name"]').value;
        const contactInput = document.querySelector('.input[name="contact"]').value;
        const messageInput = document.querySelector('.textarea[name="message"]').value;

        const feedbackData = {
            name: nameInput,
            contact: contactInput,
            message: messageInput
        };

        // Здесь вы можете добавить логику отправки данных на почту или на сервер
        // Например, с использованием Fetch API или AJAX
    }

    const resetForm = () => {
        const nameInput = document.querySelector('.input[name="name"]');
        const contactInput = document.querySelector('.input[name="contact"]');
        const messageTextarea = document.querySelector('.textarea[name="message"]');

        nameInput.style.borderColor = '#c9c9c9';
        contactInput.style.borderColor = '#c9c9c9';
        messageTextarea.style.borderColor = '#c9c9c9';

        nameInput.value = '';
        contactInput.value = '';
        messageTextarea.value = '';
    }
});
