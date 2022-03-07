
import Prism from 'prismjs';

const docsNavElems: NodeListOf<Element> = document.querySelectorAll("#Docs-nav-item");
const blogNavElems: NodeListOf<Element> = document.querySelectorAll("#Blog-nav-item");
const roadmapNavElems: NodeListOf<Element> = document.querySelectorAll("#Roadmap-nav-item");

const onPageNavElems: Element[] =[...docsNavElems, ...blogNavElems, ...roadmapNavElems];
onPageNavElems.forEach((current, index, array) => {
    current.addEventListener("click", (e: Event) => {
        onPageNavElems.forEach(navElem => {
            if ((navElem as HTMLElement).dataset.key == (current as HTMLElement).dataset.key) {
                navElem.classList.add("element__anchor--active");
                navElem.classList.remove("element__anchor--inactive");
            } else {
                navElem.classList.add("element__anchor--inactive");
                navElem.classList.remove("element__anchor--active");
            }


        });
        document.querySelectorAll(".main__section").forEach(section => {

            if ((section as HTMLElement).dataset.key == (current as HTMLElement).dataset.key) {
                section.classList.remove("main__section--hidden");
            } else {
                section.classList.add("main__section--hidden");
            }
        });
    });
});

//const pageFooter = document.querySelectorAll(".body__footer")[0];
const pageHeader: Element = document.querySelectorAll(".body-container__header")[0];
const brandDisplay: Element = document.querySelectorAll(".header__brand-display")[0];

// add css modifiers for index page. This is required as the heading and footer
// layouts are shared across all pages.
// and the index page has a bigger height value for its top nav bar and hero section
//compared to the nav bar height in the other pages
if (window.location.pathname.trim() == "/") {
    pageHeader.classList.add("body-container__header--index-page");
} else {
    pageHeader.classList.remove("body-container__header--index-page");
    brandDisplay.classList.add("header__brand-display--hidden");
}
Prism.highlightAll();
