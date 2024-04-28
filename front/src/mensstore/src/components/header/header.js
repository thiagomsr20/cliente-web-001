import './header.css'

export default function Header() {
    return (
        <div className="header">
            <div className='header-container'>
                <div className='links-container'>
                    <h1>MEN'S <span className='store'>STORE</span></h1>

                    <nav className='links'>
                        <a href="/">NOVO!</a>
                        <a href="/about">Camisetas</a>
                        <a href="/about">Calças</a>
                        <a href="/about">Acessórios</a>
                        <a href="/about">Calçados</a>
                    </nav>
                </div>

                <div className='search-carrinho-container'>
                    <div className='textbox-pesquisa'>
                        <input type="text" placeholder="procurar"></input>
                        <i class="fa-sharp fa-regular fa-magnifying-glass search-icon"></i>
                    </div>

                    <div className='carrinho-div'>
                        <i class="fa-solid fa-cart-shopping"></i>
                    </div>
                </div>
            </div>
        </div>
    )
}