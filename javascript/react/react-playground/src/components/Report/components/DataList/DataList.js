import * as React from "react";
import "./DataList.css"

export default class DataList extends React.Component {
    render() {
        return <ul className="data-list-container">
            {[1, 2, 3].map(item => <li className="data-list-item">Wassup, I'm your data list item {item}</li>)}
        </ul>
    }
}