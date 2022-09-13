using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class WordContext : DbContext
{
    public DbSet<Word> Words { get; set; }

    public string DbPath { get; }

    public WordContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "word.db");
        Database.EnsureCreated();
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Word
{
    public int WordId { get; set; }
    public string SavedWord { get; set; }

}
