import React from 'react';
import Form from './Form';
import WeatherDetails from './WeatherDetails';
import { Weather } from '../types/Weather'
import { Country } from '../types/Country';
import { CurrentCondition } from '../types/CurrentCondition';
import { City } from '../types/City';
import { CityMetaData } from '../types/CityMetaData';
import { Constants } from '../Constants';
import { ThunkDispatch } from 'redux-thunk';
import { AppActions } from '../types/actions';
import { bindActionCreators } from "redux";
import { getCountries } from "../actions/actions";
import { connect } from 'react-redux';

interface IState {
    weather: Weather,
    countries: Country[],
    city?: City
};

interface IDispatchProps {
    getCountries: () => void;
}

class Home extends React.Component<IDispatchProps, IState> {
    public state: IState = {
        weather: {
            error: ""
        } as Weather,
        countries: [],
        city: undefined
    }

    async setStateAsync(state: IState) {
        return new Promise((resolve: any) => {
            this.setState(state, resolve);
        });
    }

    async componentDidMount() {
        try {
            this.props.getCountries();
        } catch (error) {

        }
    }
   
    render() {
        return (
            <div className="container content panel">
                <div className="container">
                    <div className="row">
                        <div className="form-container">
                            <WeatherDetails />
                            <Form />
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const mapDispatchToProps = (dispatch: ThunkDispatch<any, any, AppActions>): IDispatchProps => ({
    getCountries: bindActionCreators(getCountries, dispatch),
});

export default connect(null, mapDispatchToProps)(Home);