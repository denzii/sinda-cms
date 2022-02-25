
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
        document.querySelectorAll(".section").forEach(section => {
            if ((section as HTMLElement).dataset.key == (current as HTMLElement).dataset.key) {
                section.classList.remove("section--hidden");
            } else {
                section.classList.add("section--hidden");
            }
        });
    });
});

