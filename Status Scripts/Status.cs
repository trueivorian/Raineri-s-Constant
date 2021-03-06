﻿/**
 * Status
 *
 * Storing other detailed statuses within this class will make things neater.
 *
 * Physical resistance and magical resistance will be calculated from other factors.
**/

public class Status {
    public Health health;
    //public Mana mana;
    public PhyiscalResistance phyiscalResistance;
    public MagicalResistance magicalResistance;

    public Status(float _hea, float _phyR, float _magR) {
        this.health = new Health(_hea);
        this.phyiscalResistance = new PhyiscalResistance(_phyR);
        this.magicalResistance = new MagicalResistance(_magR);
    }
}
