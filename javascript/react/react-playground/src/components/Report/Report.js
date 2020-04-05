import * as React from "react";
import DecadeSelector from '../DecadeSelector/DecadeSelector';
import DataTable from '../DataTable/DataTable';
import { topAlbums } from './../../repository/repository'

export default class Report extends React.Component {

    constructor(props) {
        super(props);

        const topAlbumsInDecade = this.getTopAlbumsInDecade(this.props.decade);
        this.handleUpdateDecade = this.handleUpdateDecade.bind(this);

        this.state = {
            albums: topAlbumsInDecade,
            decade: this.props.decade
        };

    }

    getTopAlbumsInDecade(decade) {
        return topAlbums.filter(item => {
            const startYear = Number.parseInt(decade);
            const endYear = startYear + 10;
            return item.year >= startYear && item.year < endYear;
        });
    }

    handleUpdateDecade(e, decade) {
        const albums = this.getTopAlbumsInDecade(decade);
        this.setState({
            albums: albums,
            decade: decade})
    }

    render() {
        return !this.state.albums ? <p>"Waiting for data"</p> :

        <div className="report">
            <h1>Wassup, I'm your Top 500 albums report</h1>
            <p>My containing application passes me some initial data &mdash; specifically, a decade that should be preselected: <code>{this.props.decade}</code></p>
            <p>I also store my own data: a selection of albums matching the selected decade. I render the albums using <code>DataTable</code>.</p>
            <p>I pass the preselected decade to <code>DecadeSelector</code>. <code>DecadeSelector</code> can then be used to select another decade. When it does, it should pass the selected decade up to me. In turn, I will make a new album selection matching the new decade, and pass the results to both <code>DecadeSelector</code> (new selected decade) and <code>DataTable</code> (a new set of albums)</p>

            <DecadeSelector decade={this.state.decade} updateDecade={this.handleUpdateDecade}/>

            <DataTable albums={this.state.albums}/>
        </div>
    }
}