const rawMarkdownClass = "fbrawmarkdown";
const parsedMarkdownClass = "fbparsedmarkdown";

const parseMarkdownElement = element => {
	element.innerHTML = markdownToHTML(element.innerHTML);
	element.classList.add(parsedMarkdownClass);
};
const fixClassList = element => element.classList.remove(rawMarkdownClass);

function parseMarkdownPage() {
	Array.prototype.forEach.call(document.getElementsByClassName(rawMarkdownClass),parseMarkdownElement);
	Array.prototype.forEach.call(document.getElementsByClassName(parsedMarkdownClass),fixClassList);
}

document.addEventListener("DOMContentLoaded", () => {
	parseMarkdownPage();
});