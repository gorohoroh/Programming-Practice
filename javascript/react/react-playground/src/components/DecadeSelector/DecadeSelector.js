import * as React from "react";

export default class DecadeSelector extends React.Component {
    render() {

        const decades = [
            { startYear: "1940" },
            { startYear: "1950" },
            { startYear: "1960" },
            { startYear: "1970" },
            { startYear: "1980" },
            { startYear: "1990" },
            { startYear: "2000" },
            { startYear: "2010" },
            { startYear: "2020" }
        ].map(decade => {
            if (decade.startYear === this.props.decade) decade.active = true;
            return decade;
        });

        return <div className="decade-selector">

            <p>Wassup, I'm a decade selector. I display a set of decades available for selection, and highlight the selected decade. When someone selects a new decade, I pass that to my parent, <code>Report</code>, to refresh data and re-render myself and <code>DataTable</code>.</p>

            <ul className="decade-selector-list">
                {decades.map(item => item.active ?
                    <li key={item.startYear} className="decade-active">{item.startYear}s</li> :
                    <li key={item.startYear}>
                        <button type="button" className="link-button"
                                onClick={e => this.props.updateDecade(e, item.startYear)}>{item.startYear}s
                        </button>
                    </li>)
                }
            </ul>
        </div>;
    }

}