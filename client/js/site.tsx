"use strict"
import * as React from "react";
import * as ReactDOM from "react-dom";

document.body.onload = render;

function render() {
    const jsx: JSX.Element = <div>Hello world from react</div>;
    //ReactDOM.render(jsx, document.getElementById("root"));
}