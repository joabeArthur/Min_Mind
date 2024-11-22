using FFImageLoading.Maui;

namespace Min_Mind;

public class Inimigo
{
    Image ImageView;

    public Inimigo(Image ugauga)
    {
        ImageView = ugauga;
    }

    public void MoveX(double s)
    {
        ImageView.TranslationX -= s;
    }

    public double GetX()
    {
        return ImageView.TranslationX;
    }

    public void Reset()
    {
        ImageView.TranslationX = 500;
    }
}