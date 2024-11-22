using FFImageLoading.Maui;

namespace Min_Mind;

public class Inimigos
{
    List<Inimigo> inimigos = new List<Inimigo>();
    Inimigo atual = null;
    double minX = 0;

    public Inimigos(Double ugauga)
    {
        minX = ugauga;
    }

    public void Add(Inimigo ugauga)
    {
        inimigos.Add(ugauga);

        if (atual == null)
        {
            atual = ugauga;
            Iniciar();
        }
    }

    public void Iniciar()
    {
        foreach (var e in inimigos)
        {
            e.Reset();
        }
    }

    void Gerencia()
    {
        if (atual.GetX() < minX)
        {
            Iniciar();
            var r = Random.Shared.Next(0, inimigos.Count);
            atual = inimigos[r];
        }
    }

    public void Desenha(int veloc)
    {
        atual.MoveX(veloc);
        Gerencia();
    }
}