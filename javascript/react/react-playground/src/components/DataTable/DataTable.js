import * as React from "react";
import "./../common.css"

export default class DataTable extends React.Component {
    render() {
        return !this.props.albums.length ? "No albums in this decade" :
            <table>
                <thead>
                    <tr>
                        <th>Ranking</th>
                        <th>Artist</th>
                        <th>Name</th>
                        <th>Year</th>
                    </tr>
                </thead>
                <tbody>{
                    this.props.albums.map(album => {
                        return <tr key={album.number}>
                            <td>{album.number}</td>
                            <td>{album.artist}</td>
                            <td>{album.name}</td>
                            <td>{album.year}</td>
                        </tr>
                    })
                }</tbody>
            </table>
    }
}