namespace Min_Mind;

public partial class MainPage : ContentPage
{
	bool Morto = false;
	bool Pulando = false;
	const int TempoEntreFrames = 25;
	int Velocidade = 0;
	int Velocidade01 = 0;
	int Velocidade02 = 0;
	int Velocidade03 = 0;
	int LarguraJanela = 0;
	int AlturaJanela = 0;
	const int ForcaGravidade = 6;
	bool EstaNoChao = true;
	bool EstaNoAr = false;
	bool EstaPulando = false;
	int TempoPulando = 0;
	int TempoNoAr = 0;
	const int MaxTempoPulando = 6;
	const int MaxTempoAr = 4;
	const int ForcaPulo = 8;


	Player player;
	Inimigos inimigos;

	public MainPage()
	{
		InitializeComponent();
		player = new Player(ImgOmano);
		player.Run();
	}


	async Task Desenha()
	{
		while (!Morto)
		{
			if (inimigos != null)
			{
				inimigos.Desenha(Velocidade);
			}
			
			if (!EstaPulando && !EstaNoAr)
			{
				AplicaGravidade();
				player.Desenha();
			}
			else
			{
				AplicaPulo();
				await Task.Delay(TempoEntreFrames);
			}
		}
	}

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);

		inimigos = new Inimigos(-w);
		inimigos.Add(new Inimigo(ImgTchola));//+3
	}

	void CalculaVelocidade(double w)
	{
		Velocidade = (int)(w * 0.01);
		Velocidade01 = (int)(w * 0.001);
		Velocidade02 = (int)(w * 0.004);
		Velocidade03 = (int)(w * 0.008);
	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var cor in Fundo_ceu.Children)
			(cor as Image).WidthRequest = w;
		foreach (var na in SoleLua.Children)
			(na as Image).WidthRequest = w;
		foreach (var o in Arvore.Children)
			(o as Image).WidthRequest = w;
		foreach (var docaralh in Chao.Children)
			(docaralh as Image).WidthRequest = w;

		Fundo_ceu.WidthRequest = w * 1.5;
		SoleLua.WidthRequest = w * 1.5;
		Arvore.WidthRequest = w * 1.5;
		Chao.WidthRequest = w * 1.5;
	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenario(Fundo_ceu);
		GerenciaCenario(SoleLua);
		GerenciaCenario(Arvore);
		GerenciaCenario(Chao);
	}

	void MoveCenario()
	{
		Fundo_ceu.TranslationX -= Velocidade01;
		SoleLua.TranslationX -= Velocidade02;
		Arvore.TranslationX -= Velocidade03;
		Chao.TranslationX -= Velocidade;
	}

	void GerenciaCenario(HorizontalStackLayout hs1)
	{
		var view = (hs1.Children.First() as Image);

		if (view.WidthRequest + hs1.TranslationX < 0)
		{
			hs1.Children.Remove(view);
			hs1.Children.Add(view);
			hs1.TranslationX = view.TranslationX;
		}
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}

	void AplicaGravidade()
	{

		if (player.GetY() < 0)
		{
			player.MoveY(ForcaGravidade);
		}
		else if (player.GetY() >= 0)
		{
			player.SetY(0);
			EstaNoChao = true;
		}
	}

	void ClicaNaTela(object i, TappedEventArgs a)
	{
		EstaPulando = true;
	}

	void AplicaPulo()
	{
		EstaNoChao = false;
		if (EstaPulando && TempoPulando >= MaxTempoPulando)
		{
			EstaPulando = false;
			EstaNoAr = true;
			TempoNoAr = 0;
		}
		else if (EstaNoAr && TempoNoAr >= MaxTempoAr)
		{
			EstaPulando = false;
			EstaNoAr = false;
			TempoPulando = 0;
			TempoNoAr = 0;
		}
		else if (EstaPulando && TempoPulando < MaxTempoPulando)
		{
			player.MoveY(-ForcaPulo);
			TempoNoAr++;
		}
		else if (EstaNoAr)
		{
			TempoNoAr++;
		}
	}
	void OnGridTorred (object a, TappedEventArgs e)
    {
        if (EstaNoChao)
        {
            EstaPulando = true;
        }
    }
}

