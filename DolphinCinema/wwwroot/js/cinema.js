document.addEventListener('DOMContentLoaded', function () {
    const images = document.querySelectorAll('.cinema__image');

    images.forEach(image => {
        image.addEventListener('click', function () {
            this.classList.toggle('active');
        });

        // Добавляем событие "mouseout" для сброса эффекта при убирании курсора
        image.addEventListener('mouseout', function () {
            this.classList.remove('active');
        });
    });
});

