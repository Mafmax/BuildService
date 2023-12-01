namespace Mafmax.BuildService.BusinessLayer.Utils;

public class CollectionTraversalHelper
{
    /// <summary>
    /// Увеличивает счетчик на единицу в сторону, задаваемую параметром <see cref="clockwise"/>.
    /// </summary>
    /// <param name="length">Длина коллекции.</param>
    /// <param name="index">Текущее значение индекса.</param>
    /// <param name="clockwise">Направление. Увеличение: <see langword="true"/>.</param>
    /// <returns></returns>
    public static int IncrementIndex(int length, int index, bool clockwise) =>
        ((clockwise ? index + 1 : index - 1) + length) % length;
}