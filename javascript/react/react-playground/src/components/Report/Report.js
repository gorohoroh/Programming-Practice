import * as React from "react";
import DateSelector from '../DateSelector/DateSelector';
import DataList from '../DataList/DataList';
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
            <p>I get some initial data from my containing application &mdash; that is, a decade that should be preselected:</p>
            <ul>
                <li><code>{this.props.decade}</code></li>
            </ul>
            <p>I pass the preselected decade to <code>DecadeSelector</code>. <code>DecadeSelector</code> can then be used to select another decade. When it does, it should pass the selected decade up to <code>Report</code>. <code>Report</code> should made a new album selection matching the new decade, and pass the results to both <code>DecadeSelector</code> (new selected decade) and <code>DataList</code> (a new set of albums)</p>
            <p>I also store my own data: a selection of albums matching a selected decade. I render the albums using <code>DataList</code>.</p>

            <DateSelector decade={this.state.decade} updateDecade={this.handleUpdateDecade}/>

            <DataList albums={this.state.albums}/>
        </div>
    }
}