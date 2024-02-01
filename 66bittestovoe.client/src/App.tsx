import {ReactElement, useState} from "react";
import Header from "./Header.tsx";
import Add from "./Add.tsx";
import View from "./View.tsx";


export enum CurrentPage {
    App,
    View,
}

function App() {
    const [currentPage, setCurrentPage] = useState<CurrentPage>(CurrentPage.App)

    const renderCurrenPage = (): ReactElement => {
        switch (currentPage) {
            case CurrentPage.App:
                return <Add/>
            case CurrentPage.View:
                return <View/>
        }
    }

    return (
        <div>
            <Header setCurrentPage={setCurrentPage}/>
            <main>
                {renderCurrenPage()}
            </main>
        </div>
    )
}

export default App;