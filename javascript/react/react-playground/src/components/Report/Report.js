import * as React from "react";
import DateSelector from '../DateSelector/DateSelector';
import DataList from '../DataList/DataList';
export default class Report extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            message: "This is Report state"
        }
    }

    render() {
        return <div style={{"background-color":"red"}}>
            <p>Wassup, I'm your whole report</p>
            <DateSelector/>
            <DataList/>
        </div>
    }
}