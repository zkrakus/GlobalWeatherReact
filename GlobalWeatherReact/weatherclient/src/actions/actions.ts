import { AppActions } from "../types/actions";
import { Constants } from "../Constants";
import Axios from "axios";
import { City } from "../types/City";
import { Weather } from "../types/Weather";
import { CurrentCondition } from "../types/CurrentCondition";
import { ThunkDispatch } from "redux-thunk"

export const getCountries = (): AppActions => ({
    type : "GET_COUNTRIES",
    payload : {
        request : {
            url: `${Constants.locationAPIUrl}/countries?apikey=${Constants.apiKey}`
        }
    }
});

export const getWeather = (countryCode: string, searchText: string) => {
    return async (dispatch: ThunkDispatch<any, any, AppActions>) => {
        try {
            var res = await Axios.get(`${Constants.locationAPIUrl}/cities/${countryCode}/search?apikey=${Constants.apiKey}&q=${searchText}`);
            const cities = res.data as City[];
            var weather = {} as Weather;
            
            if (cities.length > 0) {
                const city = cities[0];
                weather = await getCurrentWeather(city);
            }

            return dispatch({
                type: "GET_WEATHER_SUCCESS",
                payload: weather
            });
        }
        catch (e) {
            return dispatch({
                type: "GET_WEATHER_FAIL",
                error: e.isAxiosError ? e.message : JSON.stringify(e)
            });
        }
    }
}

export async function getCurrentWeather(city: City): Promise<Weather> {
    const res = await Axios.get(`${Constants.currentConditionsAPIUrl}/${city.Key}?apikey=${Constants.apiKey}`);
    const currentConditions = res.data as CurrentCondition[];
    if (currentConditions.length > 0) {
        return new Weather(currentConditions[0], city);
    }
    return {} as Weather;
}