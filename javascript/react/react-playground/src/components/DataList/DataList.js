import * as React from "react";
import "./../common.css"

export default class DataList extends React.Component {
    render() {
        return <ul className="data-list-container">
            {this.props.albums.map(album => <li className="data-list-item" key={album.number}>{album.artist}. {album.name} ({album.year})</li>)}
        </ul>
    }
}