const container = document.querySelector('.container');

container.addEventListener('click', (e) => {
  const target = e.target.closest('.btn');
  if (!target) return;

  const methods = document.querySelector(
    `.methods[data-id='${target.dataset.id}']`
  );

  methods.classList.toggle('hidden');
});
