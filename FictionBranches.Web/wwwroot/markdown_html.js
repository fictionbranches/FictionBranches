const rawMarkdownClass = "fbrawmarkdown";
const parsedMarkdownClass = "fbparsedmarkdown";

function parseMarkdownElement(element) {
	element.innerHTML = markdownToHTML(element.innerHTML);
	element.classList.remove(rawMarkdownClass);
	element.classList.add(parsedMarkdownClass);
}

function parseMarkdownPage() {
	var elements = document.getElementsByClassName(rawMarkdownClass);
	Array.prototype.forEach.call(elements,parseMarkdownElement);
}

document.addEventListener("DOMContentLoaded", () => {
	parseMarkdownPage();
});