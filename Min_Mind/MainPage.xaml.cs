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

	

	Player player;
	public MainPage()
	{
		InitializeComponent();
		player = new Player(imgOmano);
		player.Run();
	}

	async Task Desenha()
	{
		while (!Morto)
		{
			GerenciaCenarios();
			player.Desenha();
			await Task.Delay(TempoEntreFrames);
		}
	}

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
	}

	void CalculaVelocidade(double w)
	{
		Velocidade = (int) (w * 0.01);
		Velocidade01 = (int) (w * 0.001);
		Velocidade02 = (int) (w * 0.004);
		Velocidade03 = (int) (w * 0.008);
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
}

