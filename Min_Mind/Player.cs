using FFImageLoading.Maui;

namespace Min_Mind;

public delegate void CallBack();
public class Player : Animacao
{
    public Player (CachedImageView a): base (a)
    {
        for (int i = 1; i <= 20; ++i)
        {
            Animacao1.Add($"lord{i.ToString("D2")}.png");
        }
        for (int i = 1; i <= 20; i++)
        {
            Animacao2.Add($"lord{i.ToString("D2")}.png");
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
}