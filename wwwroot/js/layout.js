/******/ (function() { // webpackBootstrap
var __webpack_exports__ = {};
/*!***********************!*\
  !*** ./js/layout.tsx ***!
  \***********************/
function _toConsumableArray(arr) { return _arrayWithoutHoles(arr) || _iterableToArray(arr) || _unsupportedIterableToArray(arr) || _nonIterableSpread(); }

function _nonIterableSpread() { throw new TypeError("Invalid attempt to spread non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); }

function _unsupportedIterableToArray(o, minLen) { if (!o) return; if (typeof o === "string") return _arrayLikeToArray(o, minLen); var n = Object.prototype.toString.call(o).slice(8, -1); if (n === "Object" && o.constructor) n = o.constructor.name; if (n === "Map" || n === "Set") return Array.from(o); if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen); }

function _iterableToArray(iter) { if (typeof Symbol !== "undefined" && iter[Symbol.iterator] != null || iter["@@iterator"] != null) return Array.from(iter); }

function _arrayWithoutHoles(arr) { if (Array.isArray(arr)) return _arrayLikeToArray(arr); }

function _arrayLikeToArray(arr, len) { if (len == null || len > arr.length) len = arr.length; for (var i = 0, arr2 = new Array(len); i < len; i++) { arr2[i] = arr[i]; } return arr2; }

var docsNavElems = document.querySelectorAll("#Docs-nav-item");
var blogNavElems = document.querySelectorAll("#Blog-nav-item");
var roadmapNavElems = document.querySelectorAll("#Roadmap-nav-item");
var onPageNavElems = [].concat(_toConsumableArray(docsNavElems), _toConsumableArray(blogNavElems), _toConsumableArray(roadmapNavElems));
onPageNavElems.forEach(function (current, index, array) {
  current.addEventListener("click", function (e) {
    onPageNavElems.forEach(function (navElem) {
      if (navElem.dataset.key == current.dataset.key) {
        navElem.classList.add("element__anchor--active");
        navElem.classList.remove("element__anchor--inactive");
      } else {
        navElem.classList.add("element__anchor--inactive");
        navElem.classList.remove("element__anchor--active");
      }
    });
    document.querySelectorAll(".section").forEach(function (section) {
      if (section.dataset.key == current.dataset.key) {
        section.classList.remove("section--hidden");
      } else {
        section.classList.add("section--hidden");
      }
    });
  });
});
/******/ })()
;
//# sourceMappingURL=layout.js.map