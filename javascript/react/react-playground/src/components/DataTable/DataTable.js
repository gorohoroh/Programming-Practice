import * as React from "react";
import "./../common.css"

export default class DataTable extends React.Component {
    render() {
        return !this.props.albums.length ? <div className="data-table-placeholder">No albums in this decade</div> :
            <table className="data-table">
                <thead>
                    <tr>
                        <th onClick={e => this.props.sort(e, "number")}>Ranking</th>
                        <th onClick={e => this.props.sort(e, "artist")}>Artist</th>
                        <th onClick={e => this.props.sort(e, "name")}>Name</th>
                        <th onClick={e => this.props.sort(e, "year")}>Year</th>
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