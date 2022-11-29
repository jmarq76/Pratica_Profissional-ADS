import { Link } from "react-router-dom"
import { Header } from "../Shared/Header"

export const Empresa = () => {
    return (
        <div>
            <Header headerHome='true'/>
            <h1>Empresa</h1>
            <Link to='/cadastro/empresa'><h2>Faça o cadastro da sua Empresa</h2></Link>
            <div className="main-div-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Diam sollicitudin tempor id eu nisl nunc mi ipsum. Consequat mauris nunc congue nisi vitae. Ultrices eros in cursus turpis massa tincidunt. Viverra orci sagittis eu volutpat. Tortor dignissim convallis aenean et tortor at. Pellentesque dignissim enim sit amet. Blandit volutpat maecenas volutpat blandit aliquam etiam erat velit scelerisque. Nunc mattis enim ut tellus elementum sagittis. Tortor vitae purus faucibus ornare suspendisse sed. Auctor eu augue ut lectus arcu bibendum at. Neque convallis a cras semper auctor neque vitae tempus quam. Vitae tempus quam pellentesque nec nam aliquam. Imperdiet sed euismod nisi porta lorem mollis aliquam ut. Dui vivamus arcu felis bibendum. Sed id semper risus in hendrerit. Lobortis scelerisque fermentum dui faucibus in ornare quam viverra orci. Proin nibh nisl condimentum id venenatis a condimentum. A iaculis at erat pellentesque adipiscing commodo elit at. Lectus vestibulum mattis ullamcorper velit sed.</div>
            <div className="main-div-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et tortor at risus viverra adipiscing at in tellus. Lacus viverra vitae congue eu consequat ac. Posuere urna nec tincidunt praesent semper feugiat nibh sed. Elit duis tristique sollicitudin nibh. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo nec. Sed augue lacus viverra vitae congue eu consequat ac felis. Aliquam ultrices sagittis orci a. Arcu risus quis varius quam. Quam nulla porttitor massa id neque aliquam vestibulum morbi.</div>
        </div>
    )
}