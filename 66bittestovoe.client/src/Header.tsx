import {CurrentPage} from "./App.tsx";

type prop = {
    setCurrentPage: (cp: CurrentPage) => void
}

const Header = ({setCurrentPage}: prop) => {
    return (
        <header>
            <button onClick={() => setCurrentPage(CurrentPage.App)}> Add </button>
            <button onClick={() => setCurrentPage(CurrentPage.View)}> View </button>
        </header>
    );
};

export default Header;