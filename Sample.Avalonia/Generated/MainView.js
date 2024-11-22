(window["webpackChunkViews"] = window["webpackChunkViews"] || []).push([["MainView"],{

/***/ "./MainView/MainView.scss":
/*!********************************!*\
  !*** ./MainView/MainView.scss ***!
  \********************************/
/***/ ((module) => {

// extracted by mini-css-extract-plugin
module.exports = {};

/***/ }),

/***/ "./MainView/MainView.tsx":
/*!*******************************!*\
  !*** ./MainView/MainView.tsx ***!
  \*******************************/
/***/ ((module, exports, __webpack_require__) => {

var __WEBPACK_AMD_DEFINE_ARRAY__, __WEBPACK_AMD_DEFINE_RESULT__;!(__WEBPACK_AMD_DEFINE_ARRAY__ = [__webpack_require__, exports, __webpack_require__(/*! react */ "react"), __webpack_require__(/*! ./MainView.scss */ "./MainView/MainView.scss")], __WEBPACK_AMD_DEFINE_RESULT__ = (function (require, exports, React) {
    "use strict";
    Object.defineProperty(exports, "__esModule", ({ value: true }));
    class MainView extends React.Component {
        constructor(props) {
            super(props);
            this.onMouseOverHandler = (event) => {
                this.props.mouseOver(event.clientX, event.clientY);
            };
            this.onMouseLeaveHandler = () => {
                this.props.mouseLeave();
            };
        }
        render() {
            return (React.createElement("div", { className: "wrapper" },
                React.createElement("div", { className: "title" }, "Sample"),
                React.createElement("input", { onMouseOver: (event) => this.onMouseOverHandler(event), onMouseLeave: this.onMouseLeaveHandler })));
        }
    }
    exports["default"] = MainView;
}).apply(exports, __WEBPACK_AMD_DEFINE_ARRAY__),
		__WEBPACK_AMD_DEFINE_RESULT__ !== undefined && (module.exports = __WEBPACK_AMD_DEFINE_RESULT__));


/***/ }),

/***/ "react":
/*!************************!*\
  !*** external "React" ***!
  \************************/
/***/ ((module) => {

"use strict";
module.exports = window["React"];

/***/ })

},
/******/ __webpack_require__ => { // webpackRuntimeModules
/******/ var __webpack_exec__ = (moduleId) => (__webpack_require__(__webpack_require__.s = moduleId))
/******/ var __webpack_exports__ = (__webpack_exec__("./MainView/MainView.tsx"));
/******/ (window.Views = window.Views || {}).MainView = __webpack_exports__;
/******/ }
]);
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiR2VuZXJhdGVkL01haW5WaWV3LmpzIiwibWFwcGluZ3MiOiI7Ozs7Ozs7O0FBQUE7QUFDQTs7Ozs7Ozs7OztBQ0RBLGlHQUFPLENBQUMsbUJBQVMsRUFBRSxPQUFTLEVBQUUseUNBQU8sRUFBRSxzRUFBaUIsQ0FBQyxtQ0FBRTtBQUMzRDtBQUNBLElBQUksOENBQTZDLEVBQUUsYUFBYSxFQUFDO0FBQ2pFO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxpREFBaUQsc0JBQXNCO0FBQ3ZFLDZDQUE2QyxvQkFBb0I7QUFDakUsK0NBQStDLGdHQUFnRztBQUMvSTtBQUNBO0FBQ0EsSUFBSSxrQkFBZTtBQUNuQixDQUFDO0FBQUEsa0dBQUM7Ozs7Ozs7Ozs7OztBQ3BCRiIsInNvdXJjZXMiOlsid2VicGFjazovL1ZpZXdzLy4vTWFpblZpZXcvTWFpblZpZXcuc2NzcyIsIndlYnBhY2s6Ly9WaWV3cy8uL01haW5WaWV3L01haW5WaWV3LnRzeCIsIndlYnBhY2s6Ly9WaWV3cy9leHRlcm5hbCB3aW5kb3cgXCJSZWFjdFwiIl0sInNvdXJjZXNDb250ZW50IjpbIi8vIGV4dHJhY3RlZCBieSBtaW5pLWNzcy1leHRyYWN0LXBsdWdpblxubW9kdWxlLmV4cG9ydHMgPSB7fTsiLCJkZWZpbmUoW1wicmVxdWlyZVwiLCBcImV4cG9ydHNcIiwgXCJyZWFjdFwiLCBcIi4vTWFpblZpZXcuc2Nzc1wiXSwgZnVuY3Rpb24gKHJlcXVpcmUsIGV4cG9ydHMsIFJlYWN0KSB7XG4gICAgXCJ1c2Ugc3RyaWN0XCI7XG4gICAgT2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFwiX19lc01vZHVsZVwiLCB7IHZhbHVlOiB0cnVlIH0pO1xuICAgIGNsYXNzIE1haW5WaWV3IGV4dGVuZHMgUmVhY3QuQ29tcG9uZW50IHtcbiAgICAgICAgY29uc3RydWN0b3IocHJvcHMpIHtcbiAgICAgICAgICAgIHN1cGVyKHByb3BzKTtcbiAgICAgICAgICAgIHRoaXMub25Nb3VzZU92ZXJIYW5kbGVyID0gKGV2ZW50KSA9PiB7XG4gICAgICAgICAgICAgICAgdGhpcy5wcm9wcy5tb3VzZU92ZXIoZXZlbnQuY2xpZW50WCwgZXZlbnQuY2xpZW50WSk7XG4gICAgICAgICAgICB9O1xuICAgICAgICAgICAgdGhpcy5vbk1vdXNlTGVhdmVIYW5kbGVyID0gKCkgPT4ge1xuICAgICAgICAgICAgICAgIHRoaXMucHJvcHMubW91c2VMZWF2ZSgpO1xuICAgICAgICAgICAgfTtcbiAgICAgICAgfVxuICAgICAgICByZW5kZXIoKSB7XG4gICAgICAgICAgICByZXR1cm4gKFJlYWN0LmNyZWF0ZUVsZW1lbnQoXCJkaXZcIiwgeyBjbGFzc05hbWU6IFwid3JhcHBlclwiIH0sXG4gICAgICAgICAgICAgICAgUmVhY3QuY3JlYXRlRWxlbWVudChcImRpdlwiLCB7IGNsYXNzTmFtZTogXCJ0aXRsZVwiIH0sIFwiU2FtcGxlXCIpLFxuICAgICAgICAgICAgICAgIFJlYWN0LmNyZWF0ZUVsZW1lbnQoXCJpbnB1dFwiLCB7IG9uTW91c2VPdmVyOiAoZXZlbnQpID0+IHRoaXMub25Nb3VzZU92ZXJIYW5kbGVyKGV2ZW50KSwgb25Nb3VzZUxlYXZlOiB0aGlzLm9uTW91c2VMZWF2ZUhhbmRsZXIgfSkpKTtcbiAgICAgICAgfVxuICAgIH1cbiAgICBleHBvcnRzLmRlZmF1bHQgPSBNYWluVmlldztcbn0pO1xuIiwibW9kdWxlLmV4cG9ydHMgPSB3aW5kb3dbXCJSZWFjdFwiXTsiXSwibmFtZXMiOltdLCJzb3VyY2VSb290IjoiIn0=