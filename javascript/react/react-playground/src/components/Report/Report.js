import * as React from "react";
import DateSelector from '../DateSelector/DateSelector';
import DataList from '../DataList/DataList';
import { topAlbums } from './../../repository/repository'

export default class Report extends React.Component {

    constructor(props) {
        super(props);

        // const topAlbumsByDecade = topAlbums.filter(item => item.year)

        this.state = {
            albums: topAlbums
        };

        console.log(this.state.albums)
    }

    render() {
        return !this.state.albums ? "Waiting for data" :
        <div className="report">
            <h1>Wassup, I'm your whole report</h1>
            <p>I get some initial data from my containing application &mdash; that is, a decade that should be preselected:</p>
            <ul>
                <li><code>{this.props.decade}</code></li>
            </ul>
            <p>I pass the preselected decade to <code>DecadeSelector</code>. <code>DecadeSelector</code> can then be used to select another decade. When it does, it should pass the selected decade up to <code>Report</code>. <code>Report</code> should made a new album selection mathing the new decade, and pass the results to both <code>DecadeSelector</code> (new selected decade) and <code>DataList</code> (a new set of albums)</p>
            <p>I also store my own data: a selection of albums matching a selected decade. It pass it to <code>DateSelector</code> that I render with <code>DataList</code>.</p>

            <DateSelector/>

            <DataList albums={this.state.albums}/>
        </div>
    }
}