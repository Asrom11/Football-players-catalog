import {useEffect, useState} from 'react';

export enum Gender {
    Male,
    Female
}

export interface IPlayer {
    firstName: string,
    lastName: string,
    gender: Gender,
    birthDate: string,
    teamName: string,
    country: string
}

const countries:string[] = ['Россия', 'США', 'Италия']


const AddFootballer = () => {
    const [commands, setCommands] = useState<string[]>()
    const [name, setName] = useState<string>('')
    const [secondName, setSecondName] = useState<string>('')
    const [sex, setSex] = useState<Gender>(0)
    const [birthdayDate, setBirthdayDate] = useState<Date>()
    const [command, setCommand] = useState<string>('')
    const [country, setCountry] = useState<string>("Россия")
    const [isError, setIsError] = useState<boolean>(false)
    const [isAdd, setIsAdd] = useState<boolean>(false)

    const sendFootballerData = async () => {
        setIsAdd(false)
        setIsError(false)
        const res: IPlayer = {
            firstName: name,
            lastName: secondName,
            gender: sex,
            birthDate: birthdayDate + 'T00:00:00.00Z',
            teamName: command,
            country: country
        }

        const params = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },

            body: JSON.stringify(res)
        }

        const resp = await fetch('/player/add', params)
        if (resp.ok && !commands?.includes(command)) {
            setCommands(Array.prototype.concat(commands, command))
        }
        
        if (resp.ok){
            setIsAdd(true)
        }
        
        if(resp.status===400){
            setIsError(true)
        }
    }

    const getCommands = async () => {
        const resp = await fetch('/team').then(r => r.json())
        setCommands(resp?.teams)
    }

    useEffect(() => {
        getCommands()
    }, []);

    return (
        <div>
            <div>
                <label>name</label>
                <input onChange={event => {
                    setName(event.target.value);
                }}/>
                <p>
                    Name – maximum length 30 characters, minimum length 2 symbols.
                </p>
            </div>

            <div>
                <label>secondName</label>
                <input onChange={event => {
                    setSecondName(event.target.value);
                }}/>
                <p>
                    Second Name - maximum length 30 characters, minimum length 2 symbols.
                </p>
            </div>

            <div>
                <input type={'radio'} onChange={() => {
                    setSex(Gender.Male);
                }} checked={sex === 0}/>
                <label>Male</label>
            </div>

            <div>
                <input type={'radio'} onChange={() => {
                    setSex(Gender.Female);
                }} checked={sex === 1}/>
                <label>Female</label>
            </div>

            <div>
                <label>birthdayDate</label>
                <input type={'Date'} onChange={event =>
                    setBirthdayDate(event.target.value)
                }/>
                <p>
                    Date - must not be in the future
                </p>
            </div>

            <div>
                <label>country</label>
                <select onChange={event => {
                    setCountry(event.target.value);
                }}>
                    {countries.map(el => <option key={el} value={el}> {el} </option>)}
                </select>
            </div>

            <div>
                <label>command</label>
                <input value={command} onChange={event => {
                    setCommand(event.target.value);
                }}/>

                <select onClick={event => {
                    setCommand(event.target.value);
                }}>
                    {commands?.map(el =>
                        <option> {el} </option>)
                    }
                </select>

                <p>
                    Team Name - maximum length 40 characters, minimum length 3 symbols.
                </p>
            </div>

            <button onClick={sendFootballerData}>Add</button>
            {isError && <p>check the fields for correctness</p>}
            {isAdd && <p>player has been added</p>}
        </div>
    );
};

export default AddFootballer;