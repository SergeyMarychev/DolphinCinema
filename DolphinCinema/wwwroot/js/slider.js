document.addEventListener('DOMContentLoaded', () => {
	const slides = document.querySelectorAll('.slider__item');
	const paginationLines = document.querySelectorAll('.pagination__line');
	const leftArrow = document.querySelector('.pagination__arrow-left');
	const rightArrow = document.querySelector('.pagination__arrow-right');

	let currentIndex = 0;
	let autoSlideInterval;

	const showSlide = (index) => {
		slides.forEach((slide, i) => {
			slide.style.transform = `translateX(-${index * 100}%)`;
			paginationLines[i].classList.toggle('active', i === index);
		});
	};

	const nextSlide = () => {
		currentIndex = (currentIndex + 1) % slides.length;
		showSlide(currentIndex);
	};

	const startAutoSlide = () => {
		autoSlideInterval = setInterval(nextSlide, 5000);
	};

	leftArrow.addEventListener('click', () => {
		currentIndex = (currentIndex - 1 + slides.length) % slides.length;
		showSlide(currentIndex);
	});

	rightArrow.addEventListener('click', () => {
		currentIndex = (currentIndex + 1) % slides.length;
		showSlide(currentIndex);
	});

	paginationLines.forEach((line, index) => {
		line.addEventListener('click', () => {
			currentIndex = index;
			showSlide(currentIndex);
		});
	});

	startAutoSlide();
	showSlide(currentIndex);
})