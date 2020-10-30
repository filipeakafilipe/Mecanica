using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mecanica.Modelos
{
    public class Contexto : DbContext
    {
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<TipoDeServico> TipoDeServicos { get; set; }
        public DbSet<SLA> SLAs { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var settings = JsonSerializer.Deserialize<Connection>(File.ReadAllText("connectionstrings.json"));

            optionsBuilder.UseSqlServer(settings.DefaultConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SLA>().HasData(
                    new SLA() { Id = 1, Nome = "Criado" },
                    new SLA() { Id = 2, Nome = "Em trabalho" },
                    new SLA() { Id = 3, Nome = "Finalizado" }
                );

            modelBuilder.Entity<Role>().HasData(
                    new Role() { Id = 1, Nome = "Administrador" },
                    new Role() { Id = 2, Nome = "Mecânico" },
                    new Role() { Id = 3, Nome = "Cliente" }
                );

            //modelBuilder.Entity<TipoDeServico>().HasData(
            //        new TipoDeServico() { Id = 1, Nome = "Troca do oleo, filtro de oleo, filtro de ar e filtro de combustivel", Observacoes = "Troca do Oleo" },
            //        new TipoDeServico() { Id = 2, Nome = "Troca das pastilhas de freio", Observacoes = "Troca das Pastilhas de Freio" },
            //        new TipoDeServico() { Id = 3, Nome = "Troca da correia dentada", Observacoes = "Troca da Correia Dentada" },
            //        new TipoDeServico() { Id = 4, Nome = "Troca do tensor da correia dentada", Observacoes = "Troca do Tensor da Correia Dentada" },
            //        new TipoDeServico() { Id = 5, Nome = "Troca da correia do ar condicionado", Observacoes = "Troca da Correia do ACD" },
            //        new TipoDeServico() { Id = 6, Nome = "Troca da correia da Direção Hidraulica", Observacoes = "Troca da Correia da DH" },
            //        new TipoDeServico() { Id = 7, Nome = "Alinhamento", Observacoes = "Alinhamento" },
            //        new TipoDeServico() { Id = 8, Nome = "Balanceamento", Observacoes = "Balanceamento" },
            //        new TipoDeServico() { Id = 9, Nome = "Troca da sonda lambda", Observacoes = "Troca da sonda lambda" },
            //        new TipoDeServico() { Id = 10, Nome = "Limpeza dos bicos", Observacoes = "Limpeza dos bicos" },
            //        new TipoDeServico() { Id = 11, Nome = "Limpeza do TBI", Observacoes = "Limpeza do TBI" },
            //        new TipoDeServico() { Id = 12, Nome = "Troca das velas de ignição", Observacoes = "Troca das velas de ignição" },
            //        new TipoDeServico() { Id = 13, Nome = "Troca dos cabos de vela", Observacoes = "Troca dos cabos de vela" },
            //        new TipoDeServico() { Id = 14, Nome = "Troca do radiador", Observacoes = "Troca do radiador" },
            //        new TipoDeServico() { Id = 15, Nome = "Limpeza do sistema de arrefecimento e adicionado aditivo", Observacoes = "Limpeza do sistema de arrefecimento" },
            //        new TipoDeServico() { Id = 16, Nome = "Troca do sensor de rotação", Observacoes = "Troca do sensor de rotação" },
            //        new TipoDeServico() { Id = 17, Nome = "Troca do sensor de detonação", Observacoes = "Troca do sensor de detonação" },
            //        new TipoDeServico() { Id = 18, Nome = "Montagem e desmontagem do cabeçote", Observacoes = "Montagem e desmontagem do cabeçote" },
            //        new TipoDeServico() { Id = 19, Nome = "Troca do leque", Observacoes = "Troca do leque" },
            //        new TipoDeServico() { Id = 20, Nome = "Troca do conector do TBI", Observacoes = "Troca do conector do TBI" },
            //        new TipoDeServico() { Id = 21, Nome = "Troca do pivo", Observacoes = "Troca do pivo" },
            //        new TipoDeServico() { Id = 22, Nome = "Troca da bucha da barra estabilizadora", Observacoes = "Troca da bucha da barra estabilizadora" },
            //        new TipoDeServico() { Id = 23, Nome = "Troca da articulação", Observacoes = "Troca da articulação" },
            //        new TipoDeServico() { Id = 24, Nome = "Troca do filtro de ar condicionado", Observacoes = "Troca do filtro de ar condicionado" },
            //        new TipoDeServico() { Id = 25, Nome = "Higienização do ar condicionado", Observacoes = "Higienização do ar condicionado" },
            //        new TipoDeServico() { Id = 26, Nome = "Troca do coxim dos amortecedores", Observacoes = "Troca do coxim dos amortecedores" },
            //        new TipoDeServico() { Id = 27, Nome = "Troca dos amortecedores", Observacoes = "Troca dos amortecedores" },
            //        new TipoDeServico() { Id = 28, Nome = "Troca do alternador", Observacoes = "Troca do alternador " },
            //        new TipoDeServico() { Id = 29, Nome = "Troca da bomba d'agua", Observacoes = "Troca da bomba d'agua" },
            //        new TipoDeServico() { Id = 30, Nome = "Troca da mangueira", Observacoes = "Troca da mangueira" },
            //        new TipoDeServico() { Id = 31, Nome = "Troca da ponteira ", Observacoes = "Troca da ponteira" },
            //        new TipoDeServico() { Id = 32, Nome = "Troca do reparo do trambulador", Observacoes = "Troca do reparo do trambulador" },
            //        new TipoDeServico() { Id = 33, Nome = "Teste do chicote da central da injeção", Observacoes = "Teste do chicote de central de injeção" },
            //        new TipoDeServico() { Id = 34, Nome = "Rastreamento", Observacoes = "Rastreamento" },
            //        new TipoDeServico() { Id = 35, Nome = "Troca da tampa de valvula", Observacoes = "Troca da tampa de valvula" },
            //        new TipoDeServico() { Id = 36, Nome = "Troca do cabo de embreagem", Observacoes = "Troca do cabo de embreagem" },
            //        new TipoDeServico() { Id = 37, Nome = "Troca do interruptor da luz de ré", Observacoes = "Troca do interruptor da luz de ré" },
            //        new TipoDeServico() { Id = 38, Nome = "Troca da lampada", Observacoes = "Troca da lampada" },
            //        new TipoDeServico() { Id = 39, Nome = "Troca da embreagem", Observacoes = "Troca da embreagem" },
            //        new TipoDeServico() { Id = 40, Nome = "Troca da valvula termostatica", Observacoes = "Troca da valvula termostatica" },
            //        new TipoDeServico() { Id = 41, Nome = "Troca do selo do bloco do motor de admissão", Observacoes = "Troca do selo do motor" },
            //        new TipoDeServico() { Id = 42, Nome = "Revisão do motor de partida", Observacoes = "Revisão de motor de partida" },
            //        new TipoDeServico() { Id = 43, Nome = "Limpeza do tambor de freio", Observacoes = "Limpeza do tambor de freio" },
            //        new TipoDeServico() { Id = 44, Nome = "Troca da junta da tampa de valvula", Observacoes = "Troca da junta da tampa de valvula" },
            //        new TipoDeServico() { Id = 45, Nome = "Troca do fluido do sistema de freio", Observacoes = "Troca do fluido do sistema de freio" },
            //        new TipoDeServico() { Id = 46, Nome = "Troca do rolamento", Observacoes = "Troca do rolamento" },
            //        new TipoDeServico() { Id = 47, Nome = "Revisão do alternador", Observacoes = "Revisão do alternador" },
            //        new TipoDeServico() { Id = 48, Nome = "Troca dos discos de freios", Observacoes = "Troca dos discos de freios" },
            //        new TipoDeServico() { Id = 49, Nome = "Troca do atuador da marcha-lenta", Observacoes = "Troca do atuador da marcha-lenta" },
            //        new TipoDeServico() { Id = 50, Nome = "Troca da caixa de direção", Observacoes = "Troca da caixa de direção" },
            //        new TipoDeServico() { Id = 51, Nome = "Troca do termostato", Observacoes = "Troca do termostato" },
            //        new TipoDeServico() { Id = 52, Nome = "Troca da buchas do leque", Observacoes = "Troca da buchas do leque" },
            //        new TipoDeServico() { Id = 53, Nome = "Regulagem do freio de mão", Observacoes = "Regulagem do freio de mão" },
            //        new TipoDeServico() { Id = 54, Nome = "Troca da bucha do braço oscilante", Observacoes = "Troca da bucha do braço oscilante" },
            //        new TipoDeServico() { Id = 55, Nome = "Troca do batente do amortecedor", Observacoes = "Troca do batente do amortecedor" },
            //        new TipoDeServico() { Id = 56, Nome = "Reparo do comutador de ignição", Observacoes = "Reparo do comutador de ignição" },
            //        new TipoDeServico() { Id = 57, Nome = "Troca do tanque de combustivel", Observacoes = "Troca do tanque de combustivel" },
            //        new TipoDeServico() { Id = 58, Nome = "Troca da bomba de combustivel", Observacoes = "Troca da bomba de combustivel" },
            //        new TipoDeServico() { Id = 59, Nome = "Troca do anti-chama", Observacoes = "Troca do anti-chama" },
            //        new TipoDeServico() { Id = 60, Nome = "Troca do atuador hidraulico", Observacoes = "Troca do atuador hidraulico" },
            //        new TipoDeServico() { Id = 61, Nome = "Troca da bomba de oleo", Observacoes = "Troca da bomba de oleo" },
            //        new TipoDeServico() { Id = 62, Nome = "Troca das palhetas do limpador de parabrisas", Observacoes = "Troca das palhetas" },
            //        new TipoDeServico() { Id = 63, Nome = "Troca da buzina", Observacoes = "Troca da buzina" },
            //        new TipoDeServico() { Id = 64, Nome = "Troca do cilindro mestre", Observacoes = "Troca do cilindro mestre" },
            //        new TipoDeServico() { Id = 65, Nome = "Troca do cubo do sistema de freio", Observacoes = "Troca do cubo" },
            //        new TipoDeServico() { Id = 66, Nome = "Troca da junta de cabeçote", Observacoes = "Troca da junta de cabeçote" },
            //        new TipoDeServico() { Id = 67, Nome = "Troca da homocinetica", Observacoes = "Troca da homocinetica" },
            //        new TipoDeServico() { Id = 68, Nome = "Troca da mola", Observacoes = "Troca da mola" },
            //        new TipoDeServico() { Id = 69, Nome = "Limpeza do reservatorio do sistema de freio", Observacoes = "Limpeza do reservatorio do sistema de freio" },
            //        new TipoDeServico() { Id = 70, Nome = "Troca das sapatas de freio", Observacoes = "Troca das sapatas de freio" },
            //        new TipoDeServico() { Id = 71, Nome = "Troca do sensor de nivel de combustivel", Observacoes = "Troca do sensor de nivel de combustivel" },
            //        new TipoDeServico() { Id = 72, Nome = "Troca do sensor de pressão de oleo", Observacoes = "Troca do sensor de pressão de oleo" },
            //        new TipoDeServico() { Id = 73, Nome = "Troca do sensor de velocidade", Observacoes = "Troca do sensor de velocidade" },
            //        new TipoDeServico() { Id = 74, Nome = "Troca do sensor de pressão de agua", Observacoes = "Troca do sensor de pressão de agua" },
            //        new TipoDeServico() { Id = 75, Nome = "Troca do sensor de temperatura", Observacoes = "Troca do sensor de temperatura" },
            //        new TipoDeServico() { Id = 76, Nome = "Troca do sensor MAP", Observacoes = "Troca do sensor MAP" },
            //        new TipoDeServico() { Id = 77, Nome = "Troca da tampa de oleo", Observacoes = "Troca da tampa de oleo" },
            //        new TipoDeServico() { Id = 78, Nome = "Troca da trizeta", Observacoes = "Troca da trizeta" },
            //        new TipoDeServico() { Id = 79, Nome = "Troca do pescador da bomba de oleo", Observacoes = "Troca do pescador da bomba de oleo" },
            //        new TipoDeServico() { Id = 80, Nome = "Troca do flexivel do freio", Observacoes = "Troca do flexivel do freio" },
            //        new TipoDeServico() { Id = 81, Nome = "Troca da valvula de admissão", Observacoes = "Troca da valvula de admissão" },
            //        new TipoDeServico() { Id = 82, Nome = "Troca da chave de seta", Observacoes = "Troca da chave de seta" },
            //        new TipoDeServico() { Id = 83, Nome = "Troca do comutador de ignição", Observacoes = "Troca do comutador de ignição" }
            //     );
        }
    }
}
