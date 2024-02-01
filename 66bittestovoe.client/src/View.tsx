import {useEffect, useState} from "react";
import {Gender, IPlayer} from "./AddFootballer.tsx";

export interface IPlayerForView extends IPlayer {
    playerId: string
}

const countries:string[] = ['Россия', 'США', 'Италия']

const View = () => {
    const [allPlayers, setAllPlayers] = useState<IPlayerForView[]>()
    const [isRefactornig, setIsRefactornig] = useState<boolean>(false)
    const [refactoringPlayer, setRefactoringPlayer] = useState<IPlayerForView>()

    const [commands, setCommands] = useState<string[]>()
    const [name, setName] = useState<string>('')
    const [secondName, setSecondName] = useState<string>('')
    const [sex, setSex] = useState<Gender>(0)
    const [birthdayDate, setBirthdayDate] = useState<string>()
    const [command, setCommand] = useState<string>('')
    const [country, setCountry] = useState<string>("Россия")
    const [isError, setIsError] = useState<boolean>(false)

    const getPlayers = async () => {
        const resp = await fetch('/player').then(r => r.json())
        setAllPlayers(resp)
    }

    const getCommands = async () => {
        const resp = await fetch('/team').then(r => r.json())
        setCommands(resp?.teams)
    }

    useEffect(() => {
        getCommands()
    }, []);

    useEffect(() => {
        getPlayers()
    }, []);

    const refactorPlayer = (el: IPlayerForView) => {
        setIsRefactornig(true)
        setName(el.firstName)
        setSecondName(el.lastName)
        setSex(el.gender)
        setBirthdayDate(el.birthDate?.slice(0, 10))
        setCommand(el.teamName)
        setCountry(el.country)
        setRefactoringPlayer(el)
    }
    
    const changeData = async () => {
        setIsError(false)

        const res: IPlayerForView = {
            firstName: name,
            lastName: secondName,
            gender: sex,
            birthDate: birthdayDate + 'T00:00:00.00Z',
            teamName: command,
            country: country,
            playerId: refactoringPlayer?.playerId || ''
        }

        const params = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },

            body: JSON.stringify(res)
        }

        const resp = await fetch('/player/edit', params)
        if(resp.ok){
            await getPlayers()
            setIsRefactornig(false)
        }

        if (resp.status===400){
            setIsError(true)
        }
    }

    if (!isRefactornig) {
        return (
            <div>
                {allPlayers?.map(el =>
                    <p key={el.playerId}> firstName: {el.firstName},
                        lastName: {el.lastName},
                        gender: {el.gender ? "Famale" : "Male"},
                        birthDate: {el.birthDate?.slice(0, 10)},
                        teamName: {el.teamName},
                        country: {el.country}
                        <button onClick={() => refactorPlayer(el)}>Изменить</button>
                    </p>
                )}
            </div>
        )
    } else {
        return (
            <div>
                <div>
                    <label>name</label>
                    <input value={name} onChange={event => {
                        setName(event.target.value);
                    }}/>
                    <p>
                        Name – maximum length 30 characters, minimum length 2 symbols.
                    </p>
                </div>

                <div>
                    <label>secondName</label>
                    <input value={secondName} onChange={event => {
                        setSecondName(event.target.value);
                    }}/>
                    <p>
                        Second Name - maximum length 30 characters, minimum length 2 symbols.
                    </p>
                </div>

                <div>
                    <input  type={'radio'} onChange={() => {
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
                    <input value={birthdayDate} type={'Date'} onChange={event =>
                        setBirthdayDate(event.target.value)
                    }/>
                </div>

                <div>
                    <label>country</label>
                    <select value={country} onChange={event => {
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

                <button onClick={changeData}>Change</button>
                <button onClick={()=> setIsRefactornig(false)}>Exit</button>
                {isError && <p>check the fields for correctness</p>}
            </div>
        )
    }
};

export default View;