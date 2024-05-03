namespace EnumsAndFlags;

[Flags]
public enum AllowedKeys
{
    W = 0b_0000_0000,  // 0
    A = 0b_0000_0001,  // 1
    S = 0b_0000_0010,  // 2
    D = 0b_0000_0100,  // 4
    Ctrl = 0b_0000_1000,  // 8
    LShift = 0b_0001_0000,  // 16
    Letters = W | A | S | D,
    Special = Ctrl | LShift
}