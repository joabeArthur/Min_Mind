using FFImageLoading.Maui;

namespace Min_Mind;

public delegate void CallBack();
public class Player : Animacao
{
    public Player (CachedImageView ugauga) : base (ugauga)
    {
        for (int i = 1; i <= 20; ++i)
        {
            Animacao1.Add($"lord{i.ToString("D2")}.png");
        }
        for (int i = 1; i <= 2; i++)
        {
            Animacao2.Add($"booga{i.ToString("D2")}.png");
            SetAnimacaoAtiva(1);
        }
    }
    public void Die()
    {
        Loop = false;
        SetAnimacaoAtiva(2);
    }
    public void Run()
    {
        Loop = true;
        SetAnimacaoAtiva(1);
        Play();
    }

    public void MoveY(int s)
    {
        ImageView.TranslationY += s;
    }

    public double GetY()
    {
        return ImageView.TranslationY;
    }

    public void SetY(double a)
    {
        ImageView.TranslationY = a;
    }
}