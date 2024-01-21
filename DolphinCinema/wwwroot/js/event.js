document.addEventListener('DOMContentLoaded', function () {
	var maxCharacters = 100; // Максимальное количество символов
	var elements = document.querySelectorAll('.event__content'); // Получаем все элементы с классом 'event__content'

	elements.forEach(function (element) {
		var content = element.textContent.trim(); // Получаем текст из элемента и удаляем лишние пробелы в начале и в конце

		if (content.length > maxCharacters) {
			var truncatedContent = content.slice(0, maxCharacters) + '...'; // Обрезанный текст
			element.textContent = truncatedContent; // Заменить текст
		}
	});
});
